import React, { Component } from "react";
import Navbar from "./Components/Navbar";
import "./App.css";

class App extends Component {
  render() {
    return (
      <div>
        <Navbar />
        <h1 className="App">Mini Jira</h1>
      </div>
    );
  }
}

export default App;
