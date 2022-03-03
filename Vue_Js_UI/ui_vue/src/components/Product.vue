<template>
    <div>
    <h1>Product </h1>
    <b-table striped hover :items="list" :fields="fields"></b-table>
    </div>
</template>
<script>
import axios from 'axios'
// import VueAxios from 'vue-axios'
// Vue.useAttrs(VueAxios.axios)
export default{
    name:"ProductList",
    data(){
        return{       
        fields: ['Product', 'Quantity', 'Price', 'DateTime','Action'],
        list:undefined
}
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
            this.list=resp.data;
            console.warn(resp.data)
        })
    }
}
</script>

