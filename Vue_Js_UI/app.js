const routes=[
    {path:'/home',component:home},
    {path:'/product',component:department}
]

const router=new VueRouter({
    routes
})

const app = new Vue({
    router
}).$mount('#app')