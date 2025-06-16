<template>
    <main>
        <section v-if="todos.length == 0">{{ message }}</section>
        <section v-else>
            <Todo v-for="todo in todos"
                :title="todo.title"
                :description="todo.description"
                :date="todo.date"
                :isDone="todo.isDone"
                :editable="editable"
                @emitDeleteTodo="$emit('deleteTodoFromDb', todo.id)"
                @emitEditTodo="(todoData) => $emit('emitTriggerEditTodo', todo.id, todoData)"
                @emitDoneTodo="(todoDone) => $emit('doneTodoInDb', todo.id)"
                />
        </section>
    </main>
</template>

<script>
    import Todo from './Todo.vue';

    export default {
        props: ['todos', 'editable', 'message'],
        components: {
            Todo
        },
    }
</script>

<style lang="css" scoped>

main {
    padding: 20px;
}

</style>