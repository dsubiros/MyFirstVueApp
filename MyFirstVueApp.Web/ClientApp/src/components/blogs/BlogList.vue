<template>

  <v-container>
    <v-row class="text-center">
      <v-col>
        <h1>Blog List</h1>

        <v-data-table>
          :headers="headers"
          :items="todos"
          :items-per-page="5"
          class="elevation-1"
          ></v-data-table>
      </v-col>
    </v-row>
  </v-container>
</template>


<script lang="ts">
interface Todo {}
import { Component, Prop, Vue } from "vue-property-decorator";



@Component
export default class BlogList extends Vue {
  // @Prop() private msg!: string;

  todos: Todo[] = [];


}
</script>


<style scoped>

</style>