<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <button
        class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full"
      >
        <router-link to="/" class="navbar-brand">All Product</router-link>
      </button>

      <button
        class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full"
      >
        <router-link to="/add" class="nav-link">Add Product</router-link>
      </button>
    </nav>
    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>

<script>
import "./assets/tailwind.css";""
export default {
  name: "app",
  data(){
  },
};
</script>
