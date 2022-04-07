import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:50370/api/",
  headers: {
    "Content-type": "application/json"
  }
});
