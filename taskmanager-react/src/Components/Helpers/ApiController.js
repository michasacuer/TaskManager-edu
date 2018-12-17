import axios from "axios";

export default {
  api(url) {
    return {
      getAll: () =>
        url == "projects"
          ? axios.get("https://localhost:44344/api/Projects")
          : axios.get("https://localhost:44344/api/Users"),
      delete: id => {
        url == "projects"
          ? axios.delete(`https://localhost:44344/api/Projects/${id}`)
          : axios.delete(`https://localhost:44344/api/Users/${id}`);
        window.location.reload();
      }
    };
  }
};
