import React, { Component } from "react";
import "../../Styles/Projects.css";
import ApiController from "../Helpers/ApiController";
import { ListGroup, Button, Panel } from "react-bootstrap";
import BasePanel from "../Helpers/BasePanel";
import Item from "../Helpers/Item";

class ProjectDetails extends Component {
  state = {
    project: []
  };
  componentDidMount() {
    ApiController.api("Projects")
      .getOne(this.props.match.params.id)
      .then(res => {
        console.log(res);
        this.setState({ project: res.data });
      });
  }

  render() {
    return (
      <div className="spread-panel centered">
        <BasePanel item={this.state.project} />
        <ListGroup>
          {this.state.project.map(project => {
            return (
              <Item
                item={project}
                name={project.name}
                items={this.state.listOf}
                key={project.id}
                deleteItem={this.deleteProject}
              />
            );
          })}
        </ListGroup>
      </div>
    );
  }
}

export default ProjectDetails;
