import React, { Component } from "react";
import "../Styles/Search.css";

class Search extends Component {
  state = {
    query: ""
  };

  handleInputChange = () => {
    this.setState({
      query: this.search.value
    });
  };

  render() {
    return (
      <form>
        <input
          className="spread"
          placeholder="Szukaj..."
          ref={input => (this.search = input)}
          onChange={this.handleInputChange}
        />
        <p />
      </form>
    );
  }
}

export default Search;
