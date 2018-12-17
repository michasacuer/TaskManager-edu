import React, { Component } from "react";
import "../../Styles/Projects.css";

class UserDetails extends Component {
  render() {
    return <li className="text">{this.props.user.firstName}</li>;
  }
}

export default UserDetails;
