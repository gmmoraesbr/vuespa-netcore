<template>
<div>
    <h2>Usuários</h2>
    <el-table v-loading="loading" :data="data" style="width: 100%">
        <el-table-column prop="name" label="Nome" sortable></el-table-column>
        <el-table-column prop="figureExchangeTotal" label="Total de troca" sortable></el-table-column>  
    </el-table>
</div>
</template>

<script>
export default {
    name: "UserIndex",
    data() {
        return {
            data: [],
            loading: false
        };
    },
    created() {
        let self = this;
        self.order();
    },
    methods: {
        order() {
            let self = this;

            self.loading = true;

            self.$store.state.services.userService
                .order()
                .then(r => {
                    self.loading = false;
                    self.data = r.data;
                })
                .catch(r => {
                    self.$message({
                        message: "Ocorreu um erro inesperado",
                        type: "error"
                    });
                });
        }
    }
};
</script>