import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { GenreData } from './FetchGenre';

interface AddGenreDataState {
    title: string;
    loading: boolean;
    genreData: GenreData;
}

export class AddGenre extends React.Component<RouteComponentProps<{}>, AddGenreDataState> {
    constructor(props) {
        super(props);

        this.state = { title: "", loading: true, genreData: new GenreData };
                
        var genreid = this.props.match.params["genreid"];

        // This will set state for Edit genre
        if (genreid > 0) {          

            fetch('api/Genres/Details/' + genreid)
                .then(response => response.json() as Promise<GenreData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, genreData: data });
                });
        }

        // This will set state for Add genre
        else {
            this.state = { title: "Create", loading: false, genreData: new GenreData };
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
            <h3>Genre</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        // PUT request for Edit genre.
        if (this.state.genreData.genreId) {
            fetch('api/Genres/Edit', {
                method: 'PUT',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    console.log(responseJson);
                    this.props.history.push("/fetchgenres");
                })
        }

        // POST request for Add genre.
        else {
            fetch('api/Genres/Create', {
                method: 'POST',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchgenres");
                })
        }
    }

    // This will handle Cancel button click event.
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchgenres");
    }

    // Returns the HTML Form to the render() method.
    private renderCreateForm() {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="GenreID" value={this.state.genreData.genreId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Name" defaultValue={this.state.genreData.name} required />
                    </div>
                </div >  
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Active">Gender</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="active" defaultValue={this.state.genreData.active.toString()} required>
                            <option value="">-- Select Active --</option>
                            <option value="1">Enable</option>
                            <option value="0">Disable</option>
                        </select>
                    </div>
                </div >
                
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}