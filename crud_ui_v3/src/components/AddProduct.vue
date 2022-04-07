<template>
  <LodingScreen :isLoading="isLoading"/>
  <div class="submit-form">
    <div v-if="!submitted">
      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="product">Product</label>
        <input
          type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="product"
          v-model="product.ProductName"
          name="product"
          required
        />
      </div>

      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="price">Price</label>
        <input
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="price"
          required
          v-model="product.Price"
          name="price"
        />
      </div>
      <div class="form-group">
        <label class="block text-gray-700 text-sm font-bold mb-2" for="quantity">Quantity</label>
        <input
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="quantity"
          required
          v-model="product.Quantity"
          name="quantity"
        />
      </div>
      <div class="form-group">
        <label for="checkbox">Available : </label>
        <input type="checkbox" id="checkbox" v-model="product.Available"/>
      </div>

      <button @click="saveProduct" class=" bg-blue-500 hover:bg-green-900 text-white font-bold py-1 px-4 rounded-full">Submit</button>
    </div>

    <div v-else>
      <h4>You submitted successfully!</h4>
      <button class=" bg-blue-500 hover:bg-green-900 text-white font-bold py-1 px-4 rounded-full" @click="newProduct">Add</button>
    </div>
  </div>
</template>

<script>
import ProductDataService from "../service/ProductDataService";
import LodingScreen from "../components/TheLoader.vue";

export default {
  name: "add-product",
  components: {
    LodingScreen
  },
  data() {
    return {
      isLoading: false,
      product: {
        id: null,
        title: "",
        description: "",     

      },
      submitted: false,
    };
  },
  methods: {
    saveProduct() {
      this.isLoading = true;
      var data = {
        ProductName: this.product.ProductName,
        Quantity: this.product.Quantity,
        Price: this.product.Price,
        Available:this.product.Available,
        LocalTime: this.product.LocalTime,
      };

      ProductDataService.create(data)
        .then((response) => {
          this.product.Id = response.data.Id;
          console.log(response.data);
          this.submitted = true;
          this.isLoading = false;
        })
        .catch((e) => {
          console.log(e);
        });
    },

    newProduct() {
      this.submitted = false;
      this.product = {};
      this.isLoading = false;

    },
  },
};
</script>

<style>
.submit-form {
  max-width: 300px;
  margin: auto;
}
</style>
