<template>
  <div class="list row">
    <div class="col-md-8">
      <div class="input-group mb-3">
        <input type="text" class="form-control" placeholder="Search by Product"
          v-model="Product"/>
        <div class="input-group-append">
          <button class="btn btn-outline-secondary" type="button"
            @click="searchTitle"
          >
            Search
          </button>
        </div>
      </div>
    </div>
    <div class="col-md-6">
      <h4>Product</h4>
      <ul class="list-group">
        <li class="list-group-item"
          :class="{ active: index == currentIndex }"
          v-for="(product, index) in products"
          :key="index"
          @click="setActiveProduct(product, index)"
        >
          {{ product.ProductName}}
        </li>
      </ul>

      <!-- <button class="m-3 btn btn-sm btn-danger" @click="removeAllProducts">
        Remove All
      </button> -->
    </div>
    <div class="col-md-6">
      <div v-if="currentProduct">
        <h4>Selected Product</h4>
        <div>
          <label><strong>Product:</strong></label> {{ currentProduct.ProductName }}
        </div>
        <div>
          <label><strong>Price:</strong></label> {{ currentProduct.Price }}
        </div>
        <div>
          <label><strong>Quantity:</strong></label> {{ currentProduct.Quantity }}
        </div>
        <div v-if=" currentProduct.Available === true">
          <label><strong>Available:</strong></label>YES
        </div>
        <div v-if=" currentProduct.Available === false">
          <label><strong>Available:</strong></label>NO
        </div>
        <div>
          <label><strong>Time:</strong></label> {{ currentProduct.LocalTime }}
        </div>

        <router-link :to="'/Product/' + currentProduct.Id" class="btn btn-outline-secondary">Edit</router-link>
      </div>
      <div v-else>
        <br />
      </div>
    </div>
  </div>
</template>

<script>
import ProductDataService from "../service/ProductDataService";

export default {
  name: "products-list",
  data() {
    return {
      products: [],
      currentProduct: null,
      currentIndex: -1,
      Product: ""
    };
  },
  methods: {
    retrieveProducts() {
      ProductDataService.getAll()
        .then(response => {
          this.products = response.data;
          console.log(response.data);
        })
        .catch(e => {
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
        .then(response => {
          this.products = response.data;
          console.log(response.data);
        })
        .catch(e => {
          console.log(e);
        });
    }
  },
  mounted() {
    this.retrieveProducts();
  }
};
</script>

<style>
.list {
  text-align: left;
  max-width: 750px;
  margin: auto;
}
</style>
