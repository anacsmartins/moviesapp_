import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchLoginDataState {
    loginList: LoginData[];
    loading: boolean;
}

export class FetchLogin extends React.Component<RouteComponentProps<{}>, FetchLoginDataState> {
    constructor() {
        super();
        this.state = { loginList: [], loading: true };

        fetch('api/Login/Index')
            .then(response => response.json() as Promise<LoginData[]>)
            .then(data => {
                this.setState({ loginList: data, loading: false });
            });

       // This binding is necessary to make "this" work in the callback
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderLoginTable(this.state.loginList);

        return <div>
            <h1>Login Data</h1>
            <p>
                <Link to="/addlogin">Create New</Link>
            </p>
            {contents}
        </div>;
    }

    // Handle Delete request for an login
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete login with Id: " + id))
            return;
        else {
            fetch('api/Login/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        loginList: this.state.loginList.filter((rec) => {
                            return (rec.loginId != id);
                        })
                    });
            });
        }
    }

    private handleEdit(id: number) {
        this.props.history.push("/login/edit/" + id);
    }

    // Returns the HTML table to the render() method.
    private renderLoginTable(loginList: LoginData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>LoginId</th>
                    <th>User</th>                   
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                {loginList.map(login =>
                    <tr key={login.loginId}>
                        <td></td>
                        <td>{login.loginId}</td>
                        <td>{login.username}</td>                        
                        <td>{login.email}</td>                      
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(login.loginId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(login.loginId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class LoginData {
    loginId: number = 0;
    username: string = "";
    email: string = "";   
    password_: string = "";   
} 