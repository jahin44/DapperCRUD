<template>
    <div>
        <h1>Product List</h1>
        <table border="1px">
          <tr>
            <td>Product</td>
            <td>Quantity</td>
            <td>Price</td>
         </tr>
         <tr v-for ="item in list" v-bind:key="item.Id">
            <td>{{item.Product}}</td>
            <td>{{item.Quantity}}</td>
            <td>{{item.Price}}</td>
        </tr>
        </table>
    </div>
</template>
<script>
import axios from 'axios'
// import VueAxios from 'vue-axios'
// Vue.useAttrs(VueAxios.axios)
export default{
    name:"ProductList",
    data(){
        return{list:undefined}
    },
    mounted(){
        // axios.defaults.headers.get['Access-Control-Allow-Origin'] ='*';
        axios
        .get('http://localhost:50370/api/product', {
        method: 'GET',
        mode: 'cors',
        headers: { 'Access-Control-Allow-Origin': '*' },
    })    
        .then((resp)=>{
            this.list=resp.data.data;
            console.warn(resp.data.data)
        })
    }
}
</script>

