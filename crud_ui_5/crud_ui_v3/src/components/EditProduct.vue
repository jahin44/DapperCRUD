<template>
  <div v-if="currentProduct" class="edit-form">
    <h4 class="bg-sky-900 text-white">Product</h4>
    <form class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="product"
          >Product</label
        >
        <input
          type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="product"
          v-model="currentProduct.ProductName"
        />
      </div>
      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="price"
          >Price</label
        >
        <input
          type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none"
          id="price"
          v-model="currentProduct.Price"
        />
      </div>

      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="quantity"
          >Quantity</label
        >
        <input
          type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="quantity"
          v-model="currentProduct.Quantity"
        />
      </div>
      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="time"
          >Time</label
        >
        <input
          type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="time"
          v-model="currentProduct.LocalTime"
        />
      </div>
      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="time"
          >Available :
        </label>
        <input
          type="checkbox"
          id="checkbox"
          v-model="currentProduct.Available"
        />
      </div>
    </form>

    <!-- <button class="badge badge-primary mr-2"
      v-if="currentProduct.published"
      @click="updatePublished(false)"
    >
      UnPublish
    </button>
    <button v-else class="badge badge-primary mr-2"
      @click="updatePublished(true)"
    >
      Publish
    </button> -->

    <button
      class="bg-red-700 hover:bg-red-900 text-white font-bold py-1 px-4 rounded-full"
      @click="deleteProduct"
    >
      Delete
    </button>

    <button
      type="submit"
      class="bg-green-500 hover:bg-green-700 text-white font-bold py-1 px-4 rounded-full"
      @click="updateProduct"
    >
      Update
    </button>
    <p>{{ message }}</p>
  </div>

  <div v-else>
    <br />
  </div>
</template>

<script>
import ProductDataService from "../service/ProductDataService";

export default {
  name: "product-edit",
  data() {
    return {
      currentProduct: null,
      message: "The product was Deleted successfully!",
    };
  },
  methods: {
    getProduct(id) {
      ProductDataService.get(id)
        .then((response) => {
          this.currentProduct = response.data;
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    // updatePublished(status) {
    //   var data = {
    //     id: this.currentProduct.id,
    //     title: this.currentProduct.title,
    //     description: this.currentProduct.description,
    //     published: status
    //   };

    //   ProductDataService.update(this.currentProduct.id, data)
    //     .then(response => {
    //       this.currentProduct.published = status;
    //       console.log(response.data);
    //     })
    //     .catch(e => {
    //       console.log(e);
    //     });
    // },

    updateProduct() {
      ProductDataService.update(this.currentProduct.Id, this.currentProduct)
        .then((response) => {
          console.log(response.data);
          this.message = "The product was updated successfully!";
        })
        .catch((e) => {
          console.log(e);
        });
    },

    deleteProduct() {
      ProductDataService.delete(this.currentProduct.Id)
        .then((response) => {
          console.log(response.data);
          this.$router.push({ name: "products" });
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.message = "";
    this.getProduct(this.$route.params.id);
  },
};
</script>

<style>
.edit-form {
  max-width: 300px;
  margin: auto;
}
</style>
