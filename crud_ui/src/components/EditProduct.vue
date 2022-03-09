<template>
  <div v-if="currentProduct" class="edit-form">
    <h4>Product</h4>
    <form>
      <div class="form-group">
        <label for="product">Product</label>
        <input
          type="text"
          class="form-control"
          id="product"
          v-model="currentProduct.ProductName"
        />
      </div>
      <div class="form-group">
        <label for="price">Price</label>
        <input
          type="text"
          class="form-control"
          id="price"
          v-model="currentProduct.Price"
        />
      </div>

      <div class="form-group">
        <label for="quantity">Quantity</label>
        <input
          type="text"
          class="form-control"
          id="quantity"
          v-model="currentProduct.Quantity"
        />
      </div>
      <div class="form-group">
        <label for="time">Time</label>
        <input
          type="text"
          class="form-control"
          id="time"
          v-model="currentProduct.LocalTime"
        />
      </div>
      <div class="form-group">
        <label for="time">Available : </label>
        <input type="checkbox" id="checkbox" v-model="currentProduct.Available"/>
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

    <button class="m-3 btn btn-sm btn-danger" @click="deleteProduct">
      Delete
    </button>

    <button
      type="submit"
      class="m-3 btn btn-sm btn-success"
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
  name: 'product-edit',
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
