<template>
<div>
    <h2>Usuários</h2>
    <el-table v-loading="loading" :data="data" style="width: 100%">
        <el-table-column prop="name" label="Nome" sortable></el-table-column>
        <el-table-column prop="email" label="E-mail" sortable></el-table-column>
        <el-table-column align="right">
            <template slot-scope="scope">
                <el-button type="danger" @click="remove(scope.row.userId)">Deletar</el-button>
                <el-button type="warning" @click="$router.push(`/users/${scope.row.userId}/edit`)">Editar</el-button>
            </template>
        </el-table-column>    
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
        self.getAll();
    },
    methods: {
        getAll() {
            let self = this;

            self.loading = true;

            self.$store.state.services.userService
                .getAll()
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
        },
        remove(id){
            let self = this;

            self
                .$confirm("Está seguro de realizar esta ação?", "Confirmar", {
                    confirmButtonText: "Sim",
                    cancelButtonText: "Cancelar",
                    type: "warning"
                })
                .then(() => {
                    _remove();
                })
                .catch(() => {});

                function _remove() {
                    self.$store.state.services.userService
                        .remove(id)
                        .then(r => {
                            self.loading = false;
                            self.getAll();
                        })
                        .catch(r => {
                            self.$message({
                                message: "Ocorreu um erro inesperado",
                                type: "error"
                            });
                        });
                }
        }
    }
};
</script>