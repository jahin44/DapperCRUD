<template>
<div id="app">
  <Product-list/>
  {{message}}
</div>
</template>

<script>
import ProductList from './components/ProductList';
export default {
  name:"App",
  components:{
    ProductList    
  }
}
</script>

// <style lang="scss">
// @import "~@/assets/scss/vendors/bootstrap-vue/index";
// #app {
//   font-family:  Helvetica, Arial, sans-serif;
//   -webkit-font-smoothing: antialiased;
//   -moz-osx-font-smoothing: grayscale;
//   text-align: center;
//   color: #2c3e50;
//   margin-top: 60px;
// }
// </style>
