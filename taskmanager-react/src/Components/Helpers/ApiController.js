import axios from "axios";

export default {
  api(url) {
    return {
      getAll: () => axios.get(url),
      delete: () => {
        axios.delete(url);
        window.location.reload();
      }
    };
  }
};
