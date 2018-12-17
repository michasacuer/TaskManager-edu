import React, { Component } from "react";
import Navbar from "./Components/Navbar";
import "./Styles/App.css";
import ProjectsList from "./Components/Projects/ProjectsList";
import { Route, BrowserRouter } from "react-router-dom";

class App extends Component {
  state = {
    showProjects: false
  };

  render() {
    return (
      <div>
        <Navbar />
        <BrowserRouter>
          <Route path="/projects" component={ProjectsList} />
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
