import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueLoading from 'vuejs-loading-plugin'


Vue.use(VueLoading)
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')

// Vue.use(VueLoading, {
//   dark: true, // default false
//   text: 'Ladataan', // default 'Loading'
//   loading: true, // default false
//   customLoader: myVueComponent, // replaces the spinner and text with your own
//   background: 'rgb(255,255,255)', // set custom background
//   classes: ['myclass'] // array, object or string
// })