import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";

import App from "./App";
import ProjectsList from "./Components/Projects/ProjectsList";

class Routes extends Component {
  render() {
    return (
      <Switch>
        <Route exact path="/" component={App} />
        <Route exact path="/projects" component={ProjectsList} />
      </Switch>
    );
  }
}

export default Routes;
