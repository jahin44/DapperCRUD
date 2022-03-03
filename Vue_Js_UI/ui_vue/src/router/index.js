import Vue from 'vue'
import Router from 'vue-router'
import Product from '@/components/Product'
import AddProduct from '@/components/AddProduct'
import UpdateProduct from '@/components/UpdateProduct'
import DeleteProduct from '@/components/DeleteProduct'


Vue.use(Router)
export default new Router({
    routers:[
        {
            path: '/',
            name: 'Product',
            component: Product
        },
        {
            path: '/addproduct',
            name: 'AddProduct',
            component: AddProduct
        },
        {
            path: '/updateproduct',
            name: 'UpdateProduct',
            component: UpdateProduct
        },
        {
            path: '/deleteproduct',
            name: 'DeleteProduct',
            component: DeleteProduct
        }
    ]
})