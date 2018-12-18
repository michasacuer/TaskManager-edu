import axios from "axios";

export default {
  api(url) {
    const localUrl = "https://localhost:44344/api";
    return {
      getAll: () => axios.get(`${localUrl}/${url}`),
      delete: id => axios.delete(`${localUrl}/${url}/${id}`),
      post: data => axios.post(`${localUrl}/${url}`, data),
      getOne: id => axios.get(`${localUrl}/${url}/${id}`)
    };
  }
};
