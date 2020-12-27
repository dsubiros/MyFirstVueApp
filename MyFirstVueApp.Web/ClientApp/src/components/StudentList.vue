<template>
  <div>
    <p>getMessage: {{getMessage}}</p>
    <hr>
    <ul>
      <li v-for="(blog, index) in blogs" :key="index">
        <div v-bind:style="{background: classExtraction(blog)}">
          <strong>BlogId: {{blog.blogId + 1}}</strong>
          <p>Url: {{ blog.url}}</p>
          <p>Description: {{ blog.description}}</p>
          <p>background: {{ blog.background}}</p>
          <p>Blog Enabled?: {{ blog.enabled}}</p>
          <button v-on:click="toggleBLogStatus(blog, index)">Toggle Status</button>
        </div>
      </li>
    </ul>
  </div>
</template>

<script lang="ts">

export interface Blog {
  blogId: number;
  description: string;
  url: string;
  enabled: boolean;
  createdAt: Date;
  updatedAt: Date;
  background: string;
}

import {Prop, Vue, Watch} from "vue-property-decorator";
import Component from "vue-class-component";
import axios from "axios";

@Component({
})
export default class StudentList extends Vue {
  // @Prop() private msg!: string;
  
  blogs: Blog[] = [];

  get getMessage () {
    return 'Hello getMessage';
  }
  
  async getBlogs(): Promise<void> {
    const data: Blog[] = (await axios.get('http://localhost:5000/blogs'))?.data || [];
    
    this.blogs = data.map(blog => ({...blog, enabled: false, background: 'red'}));
  }

  classExtraction(blog: Blog): string {
    return blog.background === 'red' ? 'green' : 'red';
  }
  
  toggleBLogStatus = (blog: Blog, index: number) => {
    blog.enabled = !blog.enabled;
    // blog.background = <BlogStatusStatusColor>(blog.enabled ? "green" : "false");
    blog.background = blog.enabled ? "green" : "red";
    this.$set(this.blogs, index, blog);
  } 

  async mounted() {
    console.warn('Init StudentList component');
    await this.getBlogs();
  }
}
</script>

<style scoped>
  ul {
    list-style: none;
  }
  .red {
    background: red;
  }
  .green {
    background: green;
  }
</style>