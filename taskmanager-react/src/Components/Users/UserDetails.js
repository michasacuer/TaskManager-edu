import React, { Component } from "react";
import "../../Styles/Projects.css";

class UserDetails extends Component {
  render() {
    return <li className="text">{this.props.user.login}</li>;
  }
}

export default UserDetails;
