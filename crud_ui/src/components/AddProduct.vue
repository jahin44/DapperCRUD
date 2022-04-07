<template>
  <div class="submit-form">
    <div v-if="!submitted">
      <div class="form-group">
        <label for="product">Product</label>
        <input
          type="text"
          class="form-control"
          id="product"
          required
          v-model="product.ProductName"
          name="product"
        />
      </div>

      <div class="form-group">
        <label for="price">Price</label>
        <input
          class="form-control"
          id="price"
          required
          v-model="product.Price"
          name="price"
        />
      </div>
      <div class="form-group">
        <label for="quantity">Quantity</label>
        <input
          class="form-control"
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

      <button @click="saveProduct" class="btn btn-success">Submit</button>
    </div>

    <div v-else>
      <h4>You submitted successfully!</h4>
      <button class="btn btn-success" @click="newProduct">Add</button>
    </div>
  </div>
</template>

<script>
import ProductDataService from "../service/ProductDataService";

export default {
  name: "add-product",
  data() {
    return {
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
          this.$loading(false);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    newProduct() {
      this.submitted = false;
      this.product = {};
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
