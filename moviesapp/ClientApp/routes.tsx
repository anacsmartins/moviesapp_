import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchMovies } from './components/movie/FetchMovie';
import { AddMovie } from './components/movie/AddMovie';

import { FetchGenres } from './components/genre/FetchGenre';
import { AddGenre } from './components/genre/AddGenre';

import { FetchLocations } from './components/location/FetchLocation';
import { AddLocation } from './components/location/AddLocation';

import { FetchCustomers } from './components/customer/FetchCustomer';
import { AddCustomer } from './components/customer/AddCustomer';

import { FetchLogin } from './components/login/FetchLogin';
import { AddLogin } from './components/login/AddLogin';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/home/login/' component={Home} />

    <Route path='/fetchmovies' component={FetchMovies} />
    <Route path='/addmovie' component={AddMovie} />
    <Route path='/movie/edit/:movieid' component={AddMovie} />

    <Route path='/fetchgenres' component={FetchGenres} />
    <Route path='/addgenre' component={AddGenre} />
    <Route path='/genre/edit/:genreid' component={AddGenre} />

    <Route path='/fetchlocations' component={FetchLocations} />
    <Route path='/addlocation' component={AddLocation} />
    <Route path='/location/edit/:locationid' component={AddLocation} />

    <Route path='/fetchcustomers' component={FetchCustomers} />
    <Route path='/addcustomer' component={AddCustomer} />
    <Route path='/customer/edit/:customerid' component={AddCustomer} />

    <Route path='/fetchlogin' component={FetchLogin} />
    <Route path='/addlogin' component={AddLogin} />
    <Route path='/login/edit/:loginid' component={AddLogin} />
</Layout>;