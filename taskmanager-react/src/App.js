import React, { Component } from "react";
import Navbar from "./Components/Navbar";
import "./Styles/App.css";
import ProjectsList from "./Components/Projects/ProjectsList";
import axios from "axios";

class App extends Component {
  state = {
    projects: [],
    showProjects: false
  };

  componentDidMount() {
    axios.get("https://localhost:44344/api/Projects").then(res => {
      console.log(res);
      this.setState({ projects: res.data });
    });
  }

  toggleShowProjects = () => {
    this.setState(prevState => ({
      showProjects: !prevState.showProjects
    }));
  };

  render() {
    return (
      <div>
        <Navbar toggleProjects={this.toggleShowProjects} />
        <h1 className="App-header-text">Mini Jira</h1>
        {this.state.showProjects && (
          <ProjectsList
            showProjects={this.state.showProjects}
            projects={this.state.projects}
          />
        )}
      </div>
    );
  }
}

export default App;
