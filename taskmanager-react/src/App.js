import React, { Component } from "react";
import Navbar from "./Components/Navbar";
import "./Styles/App.css";
import ProjectsList from "./Components/Projects/ProjectsList";
import axios from "axios";
import ProjectDetails from "./Components/Projects/ProjectDetails";

class App extends Component {
  state = {
    showProjects: false
  };

  toggleShowProjects = () => {
    this.setState(prevState => ({
      showProjects: !prevState.showProjects
    }));
  };

  render() {
    return (
      <div>
        <Navbar toggleProjects={this.toggleShowProjects} />
        <h1 className="App-header-text">miniJira</h1>
        {this.state.showProjects && (
          <ProjectsList projects={this.state.projects} />
        )}
      </div>
    );
  }
}

export default App;
