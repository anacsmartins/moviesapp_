import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { MovieData } from './FetchMovie';

interface AddMovieDataState {
    title: string;
    loading: boolean;
    genreList: Array<any>;
    movieData: MovieData;
}

export class AddMovie extends React.Component<RouteComponentProps<{}>, AddMovieDataState> {
    constructor(props) {
        super(props);

        this.state = { title: "", loading: true, genreList: [], movieData: new MovieData };

        fetch('api/Movies/GetGenreList')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ genreList: data });
            });

        var movieid = this.props.match.params["movieid"];

        // This will set state for Edit movie
        if (movieid > 0) {          

            fetch('api/Movies/Details/' + movieid)
                .then(response => response.json() as Promise<MovieData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, movieData: data });
                });
        }

        // This will set state for Add movie
        else {
            this.state = { title: "Create", loading: false, genreList: [], movieData: new MovieData };
        }

        // This binding is necessary to make "this" work in the callback
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm(this.state.genreList);

        return <div>
            <h1>{this.state.title}</h1>
            <h3>Movie</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        
        // PUT request for Edit movie.
        if (this.state.movieData.movieId) {
            fetch('api/Movies/Edit', {
                method: 'PUT',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    console.log(responseJson);
                    this.props.history.push("/fetchmovies");
                })
        }

        // POST request for Add movie.
        else {
            fetch('api/Movies/Create', {
                method: 'POST',
                body: data,

            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchmovies");
                })
        }
    }

    // This will handle Cancel button click event.
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchmovies");
    }

    // Returns the HTML Form to the render() method.
    private renderCreateForm(genreList: Array<any>) {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="MovieID" value={this.state.movieData.movieId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Name" defaultValue={this.state.movieData.name} required />
                    </div>
                </div >                
                
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="GenreID">Genre</label>
                    <div className="col-md-4">
                        <select className="form-control" data-val="true" name="GenreID" defaultValue={this.state.movieData.genreId.toString()} required>
                            <option value="">-- Select Genre --</option>
                            {genreList.map(genre =>
                                <option key={genre.genreId} value={genre.genreId}>{genre.name}</option>
                            )}
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