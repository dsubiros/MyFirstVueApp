<template>
  <!-- <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
  </div> -->
  <div>
<!--    <HelloWorld/>-->
<!--    <StudentList></StudentList>-->
    <h1>This is the Home component</h1>
  </div>
  
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
// import HelloWorld from "@/components/HelloWorld.vue"; // @ is an alias to /src
import StudentList from "@/components/StudentList.vue"; // @ is an alias to /src

@Component({
  components: {
    StudentList
  }
})
export default class Home extends Vue {}
</script>
