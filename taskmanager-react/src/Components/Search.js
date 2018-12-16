import React, { Component } from "react";

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
