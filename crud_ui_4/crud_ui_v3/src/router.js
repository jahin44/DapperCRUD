import { createRouter, createWebHistory } from "vue-router";
const routerHistory = createWebHistory();

const router = createRouter({
  history: routerHistory,
  routes: [
    {
      path: "/",
      alias: "/products",
      name: "products",
      component: () => import("./components/AllProduct")
    },
    {
      path: "/product/:id",
      name: "product-details",
      component: () => import("./components/EditProduct")
    },
    {
      path: "/add",
      name: "add",
      component: () => import("./components/AddProduct")
    }
  ],
  scrollBehavior() {
    return { top: 0 };
},
});
export default router;

