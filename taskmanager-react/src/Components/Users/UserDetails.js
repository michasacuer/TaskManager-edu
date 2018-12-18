import React, { Component } from "react";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";

class UserDetails extends Component {
  state = {
    user: []
  };

  componentDidMount() {
    ApiController.api("Users")
      .getOne(this.props.match.params.id)
      .then(res => {
        console.log(res);
        this.setState({ user: res.data });
      });
  }

  render() {
    return <li className="text">{this.state.user.login}</li>;
  }
}

export default UserDetails;
