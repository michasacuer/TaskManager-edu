import React, { Component } from "react";
import Navbar from "./Components/Navbar";
import "./Styles/App.css";
import ProjectsList from "./Components/Projects/ProjectsList";
import UsersList from "./Components/Users/UsersList";
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
          <div>
            <Route path="/projects" component={ProjectsList} />
            <Route path="/users" component={UsersList} />
          </div>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
