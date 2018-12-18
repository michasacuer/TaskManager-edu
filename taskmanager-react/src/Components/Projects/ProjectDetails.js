import React, { Component } from "react";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";


class ProjectDetails extends Component {
state ={
  project: []
};

componentDidMount() {
  ApiController.api("Projects").getOne(this.props.match.params.id).then(res =>{
    console.log(res);
    this.setState({project: res.data});
  });
}
  
  render() {
    return <li className="text">{this.state.project.name}</li>;
  }
}

export default ProjectDetails;
