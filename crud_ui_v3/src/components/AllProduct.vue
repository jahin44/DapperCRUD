<template>
  <LodingScreen :isLoading="isLoading"/>
  <div class="list row">
    <div class="flex">
      <div class="mb-3 xl:w-60">
        <div
          class="input-group relative flex flex-wrap items-stretch w-full mb-4"
        >
          <input
            type="search"
            class="form-control relative flex-auto min-w-0 block w-full px-3 py-1.5 text-base font-normal text-gray-700 bg-white bg-clip-padding border border-solid border-gray-300 rounded transition ease-in-out m-0 focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none"
            placeholder="Search"
            aria-label="Search"
            aria-describedby="button-addon2"
            v-model="Product"
          />
          <button
            class="btn inline-block px-6 py-2.5 bg-blue-600 text-white font-medium text-xs leading-tight uppercase rounded shadow-md hover:bg-blue-700 hover:shadow-lg focus:bg-blue-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out flex items-center"
            type="button"
            id="button-addon2"
          >
            <svg
              aria-hidden="true"
              focusable="false"
              data-prefix="fas"
              data-icon="search"
              class="w-4"
              role="img"
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 512 512"
              @click="searchTitle"
            >
              <path
                fill="currentColor"
                d="M505 442.7L405.3 343c-4.5-4.5-10.6-7-17-7H372c27.6-35.3 44-79.7 44-128C416 93.1 322.9 0 208 0S0 93.1 0 208s93.1 208 208 208c48.3 0 92.7-16.4 128-44v16.3c0 6.4 2.5 12.5 7 17l99.7 99.7c9.4 9.4 24.6 9.4 33.9 0l28.3-28.3c9.4-9.4 9.4-24.6.1-34zM208 336c-70.7 0-128-57.2-128-128 0-70.7 57.2-128 128-128 70.7 0 128 57.2 128 128 0 70.7-57.2 128-128 128z"
              ></path>
            </svg>
          </button>
        </div>
      </div>
    </div>
    <div
      class="grid grid-cols-2"
    >
    <div
      class="w-50 text-gray-900 bg-white border border-gray-200 rounded-lg dark:bg-gray-700 dark:border-gray-600 dark:text-white"
    >
      <h4 class = "bg-sky-900 text-white">Product</h4>
      <ul class="list-none">
        <li
          class="list-group-item hover:bg-sky-300 shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight 
          focus:outline-none focus:shadow-outline "
          :class="{ active: index == currentIndex }"
          v-for="(product, index) in products"
          :key="index"
          @click="setActiveProduct(product, index)"
        >
          {{ product.ProductName }}
        </li>
      </ul>
      <div style="height: 20vh"></div>

      <!-- <button class="m-3 btn btn-sm btn-danger" @click="removeAllProducts">
        Remove All
      </button> -->
    </div>
    <div
      class="w-50 text-gray-900 bg-white border border-gray-200 rounded-lg dark:bg-gray-700 dark:border-gray-600 dark:text-white"
    >
      <div v-if="currentProduct">
        <h4 class = "bg-sky-700 text-white">Selected Product</h4>
        <div class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
          <label><strong>Product:</strong></label>
          {{ currentProduct.ProductName }}
        </div>
        <div class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
          <label><strong>Price:</strong></label> {{ currentProduct.Price }}
        </div>
        <div class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
          <label><strong>Quantity:</strong></label>
          {{ currentProduct.Quantity }}
        </div>
        <div class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
          <label><strong>Time:</strong></label> {{ currentProduct.LocalTime }}
        </div>
          <div class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" v-if="currentProduct.Available === true">
          <label><strong>Available:</strong></label
          >YES
        </div>
        <div class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" v-if="currentProduct.Available === false">
          <label><strong>Available:</strong></label
          >NO
        </div>

        <router-link
          :to="'/Product/' + currentProduct.Id"
          class=" bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-4 rounded-full"
          >Edit</router-link
        >
      </div>
      <div v-else>
        <br />
      </div>
    </div>
    </div>
  </div>
</template>

<script>
import ProductDataService from "../service/ProductDataService";
 import LodingScreen from "../components/TheLoader.vue";

export default {
  name: "products-list",
  components: {
    LodingScreen
  },
  data() {
    return {
      products: [],
      currentProduct: null,
      currentIndex: -1,
      Product: "",
      isLoading: false
    };
  },
  methods: {
    retrieveProducts() {
      this.isLoading = true;
      ProductDataService.getAll()
        .then((response) => {
          this.products = response.data;
          console.log(response.data);
          this.isLoading = false;
        })
        .catch((e) => {
          this.isLoading = false;
          console.log(e);
        });
    },

    refreshList() {
      this.retrieveProducts();
      this.currentProduct = null;
      this.currentIndex = -1;
    },

    setActiveProduct(product, index) {
      this.currentProduct = product;
      this.currentIndex = index;
    },

    // removeAllProducts() {
    //   ProductDataService.deleteAll()
    //     .then(response => {
    //       console.log(response.data);
    //       this.refreshList();
    //     })
    //     .catch(e => {
    //       console.log(e);
    //     });
    // },

    searchTitle() {
      ProductDataService.findByTitle(this.Product)
        .then((response) => {
          this.products = response.data;
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.retrieveProducts();
  },
};
</script>

<style>
.list {
  text-align: left;
  max-width: 750px;
  margin: auto;
}
</style>
