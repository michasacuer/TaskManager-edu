import React, { Component } from "react";
import Navbar from "./Components/Navbar";
import "./Styles/App.css";
import ProjectsList from "./Components/Projects/ProjectsList";
import UsersList from "./Components/Users/UsersList";
import { Route, BrowserRouter } from "react-router-dom";
import ProjectDetails from "./Components/Projects/ProjectDetails";

class App extends Component {
  render() {
    return (
      <div>
        <Navbar />
        <BrowserRouter>
          <div>
            <Route exact path="/projects" component={ProjectsList} />
            <Route exact path="/users" component={UsersList} />
            <Route exact path="/projects/:id" component={ProjectDetails} />
          </div>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
