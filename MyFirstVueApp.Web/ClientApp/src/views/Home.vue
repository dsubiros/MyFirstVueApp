<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
<!--    <HelloWorld msg="Welcome to Your Vue.js App"/>-->
<!--    <NavMenu></NavMenu>-->
    <Counter></Counter>
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'
// import HelloWorld from '@/components/Home'

// import Home from "@/components/Home";

// import NavMenu from "../components/NavMenu";
import Counter from "../components/Counter";

export default {
  name: 'Home',
  // components: {
  //   // Home
  // }
  components: {
    Counter,
    // NavMenu
    // HelloWorld
  }
}
</script>
