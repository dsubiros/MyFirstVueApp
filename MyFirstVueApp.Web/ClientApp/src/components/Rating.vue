<template>
  <div>
    
    <ul :key="star" v-for="star in maxStars">
      <li class="star" :class="{active: star <= initialGrade}"></li>
    </ul>
    
    <div class="summary">{{initialGrade}} of {{maxStars}}</div>
  </div>
</template>

<script>
export default {
  name: "Rating",
  props: {
    maxStars: Number,
    initialGrade: Number
  }
}
</script>

<style scoped>

</style>