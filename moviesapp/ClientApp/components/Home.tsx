import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { LoginData } from './login/FetchLogin';

interface AddLoginDataState {
    title: string;
    loading: boolean;
    objData: LoginData;
}

export class Home extends React.Component<RouteComponentProps<{}>, AddLoginDataState> {
    constructor(props) {
        super(props);

        this.state = { title: "", loading: true, objData: new LoginData };

        var loginid = this.props.match.params["loginid"];

        // This will set state for Edit home
        if (loginid > 0) {

            fetch('api/Home/Details/' + loginid)
                .then(response => response.json() as Promise<LoginData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, objData: data });
                });
        }

        // This will set state for Add home
        else {
            this.state = { title: "Create", loading: false, objData: new LoginData };
        }

        // This binding is necessary to make "this" work in the callback
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm();

        return <div>
            <h1>{this.state.title}</h1>
            <h3>Home</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        // PUT request for Edit home.
        if (this.state.objData.loginId) {
            fetch('api/Home/login', {
                method: 'PUT',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    console.log(responseJson);
                    this.props.history.push("/fetchcustomers");
                })
        }

        // POST request for Add home.
        else {
            fetch('api/login/Create', {
                method: 'POST',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/home");
                })
        }
    }

    // This will handle Cancel button click event.
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/home");
    }

    // Returns the HTML Form to the render() method.
    private renderCreateForm() {
        return (
            <form onSubmit={this.handleSave} >                
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="UserName">UserName</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="UserName" defaultValue={this.state.objData.username} required />
                    </div>
                </div>
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Password_">Password_</label>
                    <div className="col-md-4">
                        <input className="form-control" type="password" name="Password_" defaultValue={this.state.objData.password_} required />
                    </div>
                </div>
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Email">Email</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Email" defaultValue={this.state.objData.email} required />
                    </div>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}