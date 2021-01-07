<template>
  <!--  <div id="todo-list">-->

  <!--    <div class="item-list">-->
  <!--      <form @submit.prevent="onSubmit">-->
  <!--        <input-->
  <!--            type="text"-->
  <!--            placeholder="What needs to be done?"-->
  <!--            v-model="text"-->
  <!--        />-->
  <!--      </form>-->

  <!--      <div class="info">-->
  <!--        <div>Total: {{ todos.length }}</div>-->
  <!--        <div>Done: {{ removedItemCount }}</div>-->
  <!--      </div>-->
  <!--      &lt;!&ndash;      <p>Text: {{text}}</p>&ndash;&gt;-->

  <!--      <ul>-->
  <!--        <transition-group-->
  <!--            enter-active-class="animated bounceInUp"-->
  <!--            leave-active-class="animated bounceOutDown"-->
  <!--            name="list"-->
  <!--        >-->
  <!--          <li-->
  <!--              v-for="(todo, index) in todos"-->
  <!--              :key="index"-->
  <!--              title="Click to change item status"-->
  <!--              :class="{ disabled: !todo.enabled, hovered: selectedId === index }"-->
  <!--              @click="toggleStatus(index)"-->
  <!--              @mousemove="selectedId = index"-->
  <!--          >-->
  <!--            <div>-->
  <!--              <strong>{{ todo.todoId + 1 }}- </strong>-->
  <!--              <span>&nbsp;&nbsp; {{ todo.text }}</span>-->
  <!--            </div>-->
  <!--            &lt;!&ndash;            <button @click="onEdit(index)">Edit</button>&ndash;&gt;-->
  <!--            <button @click="onRemove(index)">Remove</button>-->
  <!--          </li>-->
  <!--        </transition-group>-->
  <!--      </ul>-->
  <!--    </div>-->
  <!--    &lt;!&ndash;    <div>todos: {{todos}}</div>&ndash;&gt;-->
  <!--  </div>-->

  <v-container style="width: 800px;">
    <h1>My Vuetify Todo Manager</h1>

    <v-row class="pt-5">
      <v-col>
        <v-data-table
          :headers="headers"
          :items="todos"
          :items-per-page="5"
          class="elevation-1"
        >
          <template v-slot:item.actions="{ item }">
            <Dialog
              :is-open="showDeleteDialog"
              @result="onRemove(item)"
              title="Remove Todo"
              text="Are you sure to remove the selected item?"
              :max-width="400"
              entry-button-text="Remove"
              :show-entry-button-text="false"
              :show-entry-button-icon="true"
              entry-button-icon="mdi-delete"
              entry-button-type="plain"
              entry-button-color="error"
              v-if="item"
            />
          </template>
        </v-data-table>
      </v-col>
    </v-row>

    <Snackbar
      :text="messageText"
      @close="messageText = ''"
      ref="snackbarRef"
      :is-open="!!messageText"
    />

    <button @click="messageText = 'Open me!'">Open me</button>
  </v-container>
</template>

<script lang="ts">
import Dialog from "@/components/Dialog.vue";

export interface Todo {
  todoId?: number;
  text: string;
  enabled?: boolean;
  createdAt?: Date;
  updatedAt?: Date;
}

import { Prop, Vue, Watch } from "vue-property-decorator";
import Component from "vue-class-component";
import axios from "axios";
import Snackbar from "@/components/Snackbar.vue";

@Component({
  components: { Snackbar, Dialog }
})
export default class TodoListVuetify extends Vue {
  headers = [
    { text: "ID", value: "todoId" },
    { text: "Text", value: "text" },
    { text: "Status", value: "enabled" },
    { text: "Created At", value: "createdAt" },
    { text: "Updated At", value: "updatedAt" },
    { text: "Actions", value: "actions", sortable: false }
  ];

  showDeleteDialog = false;
  todos: Todo[] = [];
  text = "";
  selectedId = -1;
  editMode = false;
  messageText = "";

  async getTodos(): Promise<void> {
    this.todos = (
      ((await axios.get("https://localhost:5003/api/todos"))?.data as Todo[]) ||
      []
    ).map(item => ({ ...item, updatedAt: item.updatedAt || item.createdAt }));
  }

  get removedItemCount() {
    return this.todos.filter(x => !x.enabled).length;
  }

  async onSubmit() {
    console.warn("Todo submitted!");
    if (!this.text) return;

    try {
      // if (this.editMode) {
      //   const item = this.todos[this.selectedId];
      //   const data: Todo = (await axios.post('https://localhost:5003/api/todos', ))?.data;
      //   this.text = '';
      //
      //   this.editMode = false;
      // }

      const newTodo: Todo = {
        text: this.text,
        enabled: true
      };

      const data: Todo = (
        await axios.post("https://localhost:5003/api/todos", newTodo)
      )?.data;
      this.text = "";
      // this.todos = this.todos.concat(data);
      await this.getTodos();
    } catch (e) {
      console.error(e);
    }
  }

  async toggleStatus(index: number) {
    const item = this.todos[index];
    item.enabled = !item.enabled;

    try {
      const result: Todo = (
        await axios.put(`https://localhost:5003/api/todos/${item.todoId}`, item)
      )?.data;
      // this.$set(this.todos, index, result);
      await this.getTodos();
    } catch (e) {
      console.error(e);
    }
  }

  async onRemove(item: Todo) {
    try {
      // await axios.delete(`https://localhost:5003/api/todos/${item.todoId}111`);
      await axios.delete(`https://localhost:5003/api/todos/${item.todoId}`);
      this.todos = this.todos.filter(x => x.todoId !== item.todoId);
      this.$refs.snackbarRef.showInfoMessage(
        "The Todo was removed successfully."
      );
    } catch (e) {
      console.error(e);
      this.$refs.snackbarRef.showErrorMessage(
        "An error happened while removing the Todo."
      );
    }
  }

  async onEdit(index: number) {
    this.editMode = true;
    this.selectedId = index;
    this.text = this.todos[index].text;
  }

  async mounted() {
    console.warn("Init TodoListVuetify component");
    await this.getTodos();
  }
}
</script>

<style scoped lang="scss">
ul {
  list-style: none;
}
.red {
  background: red;
}
.green {
  background: green;
}

#todo-list {
  /*width: 100%;*/
  //display: flex;
  margin-left: auto;
  margin-right: auto;
  //flex-direction: column;
  //justify-content: start;
  margin-top: 100px;
  padding: 50px;
  width: 500px;

  input {
    width: 95%;
    height: 30px;
    padding: 10px;
    //border: none;
    border: 1px solid darkcyan;
  }

  .info {
    display: flex !important;
    flex-direction: row;
    justify-content: space-between;
    padding: 5px;
  }

  button {
    cursor: pointer;
    text-decoration: none;
  }

  ul {
    //width: 100%;
    padding: 10px;
    li {
      display: flex;
      flex-direction: row;
      justify-content: space-between;
      align-items: center;
      cursor: pointer;
      padding: 10px;
    }

    li.disabled {
      text-decoration: line-through;
    }

    .hovered {
      background: lightgray;
    }
  }
}
</style>
