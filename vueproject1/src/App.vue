<template>
    <div class="app">
        <img alt="Vue logo" src="./assets/logo.png">
        <h1 class="text-white text-bg-success curr container py-3">Data Inputor</h1>
        <br />
        <div class="container py-5">
            <div class="form-floating mb-3">
                <input type="text" class="form-control" v-model="nama" id="floatingInput" placeholder="Masukkan Nama">
                <label for="floatingInput">Nama</label>
            </div>
            <div class="form-floating">
                <input type="text" class="form-control" v-model="komentar" id="floatingKomentar" placeholder="Masukkan Komentar">
                <label for="floatingKomentar">Komentar</label>
            </div><br />
            <div class="d-flex justify-content-left">
                <a href="#" @click="komen" class="btn btn-primary btn-large rextras"><span class="glyphicon glyphicon-send"></span> Kirim!</a>
            </div>
        </div><br />
        <div class="container py-5 card rounded">
            <h1 v-if="!komentars" class="fw-bold">Belum ada komentar masuk..</h1>
            <table v-else style="width:100%;">
                <thead>
                    <tr>
                        <th>Nama</th>
                        <th>Komentar</th>
                    </tr>
                </thead>
           
                <tbody v-for="k in komentars" v-bind:key="k">
                    <tr>
                        <td>{{ k.nama }}</td>
                        <td>{{ k.komentar }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <BitcoinCard v-bind:currency="currency" />
    </div>
</template>

<script>
    import axios from 'axios'
    import BitcoinCard from '@/components/BitcoinCard.vue'
    import 'sweetalert2/dist/sweetalert2.min.css';
    import 'sweetalert2/dist/sweetalert2.min.js';
    export default {
        name: 'App',
        components: {
            BitcoinCard
        },
        data() {
            return {
                komentars: false,
                currency: '',
                nama: '',
                komentar: ''
            }
        },
        methods: {
            refreshData() {
                axios.get('https://localhost:5001/komentar/')
                    .then((response) => {
                        this.komentars = response.data;
                    });
              
            },
            komen() {
                if(this.nama == '' || this.komentar == ''){
                    alert('Hello Vue world!!!');
                }
            },
        },
        mounted: function () {
            this.refreshData();
            axios.get('https://api.coindesk.com/v1/bpi/currentprice.json')
                .then(response => (this.currency = response.data.bpi))
        },
      
    }
</script>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Poppins');
    .curr{
        border-radius: 35px 0 35px 0;
    }
    #app {
        font-family: Poppins, Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
    .rextras{
        border-radius:100%;
    }
</style>
