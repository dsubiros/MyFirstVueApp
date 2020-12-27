<template>
  <h1 id="tableLabel">Blogs</h1>

  <p>This component demonstrates fetching data from the server.</p>

  <p v-if="!blogs"><em>Loading...</em></p>

  
  <table class='table table-striped' aria-labelledby="tableLabel" v-if="blogs">
    <thead>
    <tr>
      <th>Id</th>
      <th>Url</th>
      <th>Description</th>
      <th>Created At</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="blog of blogs" v-bind:key="blog" @click="onClick(blog)">
      <td>{{ blog.blogId }}</td>
      <td>{{ blog.url }}</td>
      <td>{{ blog.description }}</td>
      <td>{{ blog.createdAt }}</td>
    </tr>
    </tbody>
  </table>
</template>


<script>
import axios from 'axios'
export default {
  name: "BlogList",
  data() {
    return {
      blogs: []
    }
  },
  methods: {
    onClick: (forecast) => alert('Hello!' + JSON.stringify(forecast)),
    getBlogs() {
      axios.get('http://localhost:5000/blogs')
          .then((response) => {
            this.blogs =  response.data;
          })
          .catch(function (error) {
            alert(error);
          });
    }
  },
  mounted() {
    this.getBlogs();
  }
}
</script>