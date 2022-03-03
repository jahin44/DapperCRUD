import Product from "./components/Product.vue";
import AddProduct from "./components/AddProduct.vue";
import UpdateProduct from "./components/UpdateProduct.vue";
import DeleteProduct from "./components/DeleteProduct.vue";
import {
    createRouter,
    createWebHistory
} from "vue-router";
const routes = [{
        name: "Product",
        component: Product,
        path: "/"
    },
    {
        name: "AddProduct",
        component: AddProduct,
        path: "/add-product"
    },
    {
        name: "UpdateProduct",
        component: UpdateProduct,
        path: "/update-product"
    },
    {
        name: "DeleteProduct",
        component: DeleteProduct,
        path: "/delete-product"
    },
];
const router = createRouter({
    history: createWebHistory(),
    routes,
});
export default router;