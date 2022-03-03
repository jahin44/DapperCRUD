<template>
<div id = "app">
  <h1>Hello</h1>
  <router-view/>
</div>
</template>

<script>
//import Product from './components/Product.vue'

export default {
  name: 'app',
  // components: {
  //   Product
  // }
}
</script>

<style>
#app {
  font-family: Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
