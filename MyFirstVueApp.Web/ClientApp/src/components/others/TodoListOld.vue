<template>
  <div id="todo-list">
    <h1>My Todo Manager</h1>

    <div class="item-list">
      <form @submit.prevent="onSubmit">
        <input
          type="text"
          placeholder="What needs to be done?"
          v-model="text"
        />
      </form>

      <div class="info">
        <div>Total: {{ todos.length }}</div>
        <div>Done: {{ removedItemCount }}</div>
      </div>
      <!--      <p>Text: {{text}}</p>-->

      <ul>
        <transition-group
          enter-active-class="animated bounceInUp"
          leave-active-class="animated bounceOutDown"
          name="list"
        >
          <li
            v-for="(todo, index) in todos"
            :key="index"
            title="Click to change item status"
            :class="{ disabled: !todo.enabled, hovered: selectedId === index }"
            @click="toggleStatus(index)"
            @mousemove="selectedId = index"
          >
            <div>
              <strong>{{ todo.todoId + 1 }}- </strong>
              <span>&nbsp;&nbsp; {{ todo.text }}</span>
            </div>
            <!--            <button @click="onEdit(index)">Edit</button>-->
            <button @click="onRemove(index)">Remove</button>
          </li>
        </transition-group>
      </ul>
    </div>
    <!--    <div>todos: {{todos}}</div>-->
  </div>
</template>

<script lang="ts">
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

@Component({})
export default class TodoListOld extends Vue {
  todos: Todo[] = [];
  text = "";
  selectedId = -1;
  editMode = false;

  async getTodos(): Promise<void> {
    this.todos =
      (await axios.get("https://localhost:5003/api/todos"))?.data || [];
    // this.todos = data.map(todo => ({...todo, enabled: false, background: 'red'}));
  }

  get removedItemCount() {
    return this.todos.filter(x => !x.enabled).length;
  }

  // @Watch('todos', {
  //   immediate: true, deep: true
  // })
  // projectChanged() {
  //   // this.todos
  //   // do something
  // }

  // classExtraction(todo: Todo): string {
  //   return todo.background === 'red' ? 'green' : 'red';
  // }

  // toggleBLogStatus = (todo: Todo, index: number) => {
  //   todo.enabled = !todo.enabled;
  //   // todo.background = <TodoStatusStatusColor>(todo.enabled ? "green" : "false");
  //   todo.background = todo.enabled ? "green" : "red";
  //   this.$set(this.todos, index, todo);
  // }

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

  async onRemove(index: number) {
    if (!confirm("Are you sure to delete this item?")) return;
    const item = this.todos[index];

    try {
      await axios.delete(`https://localhost:5003/api/todos/${item.todoId}`);
      this.todos = this.todos.filter(x => x.todoId !== item.todoId);
    } catch (e) {
      console.error(e);
    }
  }

  async onEdit(index: number) {
    this.editMode = true;
    this.selectedId = index;
    this.text = this.todos[index].text;
  }

  async mounted() {
    console.warn("Init TodoList component");
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
