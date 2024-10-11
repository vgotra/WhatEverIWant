<script>
	import EditPage from '$lib/components/EditPage.svelte';
	export let params;
</script>

<EditPage apiEndpoint="/api/audiobooks" id={params.id} />
