import axios from "axios";

export default {
  api(url) {
    const localUrl = "http://localhost:50139/api";
    return {
      getAll: () => axios.get(`${localUrl}/${url}`),
      delete: id => axios.delete(`${localUrl}/${url}/${id}`),
      post: data =>
        axios.post(`${localUrl}/${url}`, data).catch(function(error) {
          window.alert("Błąd serwera! Taki projekt już istnieje w bazie!");
        }),
      getOne: id => axios.get(`${localUrl}/${url}/${id}`)
    };
  }
};
