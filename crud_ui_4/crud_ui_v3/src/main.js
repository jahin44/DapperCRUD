import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import './assets/tailwind.css'
import wait from "@meforma/vue-wait-for";

const app = createApp(App);
app.use(router);
app.use(wait);
app.mount("#app");
