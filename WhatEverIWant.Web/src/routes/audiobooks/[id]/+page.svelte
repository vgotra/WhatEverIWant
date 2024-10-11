<script>
	import DetailsPage from '$lib/components/DetailsPage.svelte';
	export let params;
</script>

<DetailsPage apiEndpoint="/api/audiobooks" id={params.id} />
