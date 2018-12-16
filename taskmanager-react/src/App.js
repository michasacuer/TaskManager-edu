import React, { Component } from "react";
import Navbar from "./Components/Navbar";
import "./Styles/App.css";
import ProjectsList from "./Components/Projects/ProjectsList";
import axios from "axios";

class App extends Component {
  state = {
    projects: []
  };

  componentDidMount() {
    axios.get("https://localhost:44344/api/Projects").then(res => {
      console.log(res);
      this.setState({ projects: res.data });
    });
  }

  render() {
    return (
      <div>
        <Navbar />
        <h1 className="App-header-text">Mini Jira</h1>
        <ProjectsList projects={this.state.projects} />
      </div>
    );
  }
}

export default App;
