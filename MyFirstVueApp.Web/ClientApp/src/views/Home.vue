<template>
  <!-- <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
  </div> -->
  <div>
    <h1>This is the Home component</h1>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import StudentList from "@/components/others/StudentList.vue"; // @ is an alias to /src

@Component({
  components: {
    StudentList
  }
})
export default class Home extends Vue {}
</script>
